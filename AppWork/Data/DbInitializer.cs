using AppWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWork.Data
{
    public class DbInitializer
    {
        public static void Initialize(ManagerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Programists.Any())
            {
                return;   // DB has been seeded
            }

            var programmers = new Programist[] {
                new Programist { Id = 1, Name = "Egor", Surname = "Ivanov", Email="Ivanov@gmail.com" },
                new Programist { Id = 2, Name = "Marina", Surname = "Lozova", Email = "Lozarina@gmail.com" },
                new Programist { Id = 3, Name = "Svitlana", Surname = "Sviridova", Email = "Svetikridik@gmail.com" },
                new Programist { Id = 4, Name = "Maksum", Surname = "Pochatkin", Email = "Po4atkin@gmail.com" }
        };
            foreach (Programist s in programmers)
            {
                context.Programists.Add(s);
            }
            context.SaveChanges();

            var projects = new Proekt[]
            {
                new Proekt { Id = 1, ProjectName = "Medithin", NumberOfWorkers = 3},
                new Proekt {Id = 2,ProjectName = "Business analises",NumberOfWorkers = 2},
                new Proekt {Id =4, ProjectName="Tutorial", NumberOfWorkers=1},
                new Proekt {Id = 3,ProjectName = "Web-site creator",NumberOfWorkers = 3 }
            };
            foreach (Proekt i in projects)
            {
                context.Proekts.Add(i);
            }
            context.SaveChanges();

            var findWorkers = new Manager[]
            {
                new Manager{ProektId=projects.Single( i => i.ProjectName == "Medithin").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Lozova").Id},
                new Manager{ProektId=projects.Single( i => i.ProjectName == "Medithin").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Sviridova").Id},
                new Manager{ProektId=projects.Single( i => i.ProjectName == "Medithin").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Ivanov").Id },

                new Manager{ProektId=projects.Single( i => i.ProjectName == "Business analises").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Pochatkin").Id },
                new Manager{ProektId=projects.Single( i => i.ProjectName == "Business analises").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Ivanov").Id},

                new Manager{ProektId=projects.Single( i => i.ProjectName == "Tutorial").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Lozova").Id},

                new Manager{ProektId=projects.Single( i => i.ProjectName == "Web-site creator").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Sviridova").Id},
                new Manager{ProektId=projects.Single( i => i.ProjectName == "Web-site creator").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Lozova").Id},
                new Manager{ProektId=projects.Single( i => i.ProjectName == "Web-site creator").Id,
                    ProgramistId=programmers.Single(p => p.Surname == "Pochatkin").Id}
            };
            foreach (Manager mg in findWorkers)
            {
                context.Managers.Add(mg);
            }
            context.SaveChanges();
        }
        }
}
