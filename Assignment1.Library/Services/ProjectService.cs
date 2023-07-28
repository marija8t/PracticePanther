using System;
using Assignment1.Models;
using System.Xml.Linq;
using Assignment1.Library.Models;

namespace Assignment1.Library.Services
{
    public class ProjectService
    {
       
            private List<Project> projects;
            public List<Project> Projects
            {
                get
                {
                    return projects;
                }
            }

            private static ProjectService? instance;
            public static ProjectService Current
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new ProjectService();
                    }

                    return instance;
                }
            }

            private ProjectService()
            {
                projects = new List<Project>();
            }

            public Project? Get(int id)
            {
                return Projects.FirstOrDefault(p => p.Id == id);
            }


//-----------------------------------------------------------------ADD-----------------------------------------------------
            public void Add(Project project)
            {
                if (project.Id == 0)
                {
                    project.Id = LastId + 1;
                }
                projects.Add(project);
            }

        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(c => c.Id).Max() : 0;
            }
        }

//---------------------------------------------DELETE------------------------------------------------------
        public void Delete(int id)
        {
            var projectToDelete = Projects.FirstOrDefault(p => p.Id == id);
            if (projectToDelete != null)
            {
                Projects?.Remove(projectToDelete);
            }
        }

        public void Delete(Project p)
        {
            Delete(p.Id);
        }

//---------------------------------------------------EDIT------------------------------------------------------

        public void Edit(Project project)
        {
            Project? existingProject = Get(project.Id);
            if(existingProject != null)
            {
                existingProject.Id = project.Id;
                existingProject.ShortName = project.ShortName;
            }
        }
    }
}

