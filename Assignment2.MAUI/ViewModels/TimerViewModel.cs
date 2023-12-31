﻿using System;
using System.ComponentModel;
using Assignment1.Library.Services;
using Assignment1.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Assignment2.MAUI.ViewModels
{
	public class TimerViewModel : INotifyPropertyChanged
    {
        public Project Project { get; set; }
        public string TimerDisplay
        {
            get
            {
                return string.Format("{0:00}:{0:00}:{1:00}",
                stopwatch.Elapsed.Hours,
                stopwatch.Elapsed.Minutes,
                stopwatch.Elapsed.Seconds);
            }
        }
        public string ProjectDisplay
        {
            get
            {
                return Project.ShortName;
            }
        }

        private IDispatcherTimer timer { get; set; }
        private Stopwatch stopwatch { get; set; }

        public ICommand StartCommand { get; private set; }
        public ICommand StopCommand { get; private set; }

        public void ExecuteStart()
        {
            stopwatch.Start();
            timer.Start();
        }

        public void ExecuteStop()
        {
            stopwatch.Stop();
        }

        private void SetupCommands()
        {
            StartCommand = new Command(ExecuteStart);
            StopCommand = new Command(ExecuteStop);
        }
        public TimerViewModel(int projectId)
        {
            Project = ProjectService.Current.Get(projectId) ?? new Project();
            stopwatch = new Stopwatch();
            timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.IsRepeating = true;

            timer.Tick += Timer_Tick;
            SetupCommands();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timer.IsRunning)
            {
                NotifyPropertyChanged(nameof(TimerDisplay));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        
    }
}

