using HonglornBL.Enums;
using HonglornBL.Games.Traditional.TrackAndField;
using HonglornBL.Import;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace HonglornBL
{
    public class Honglorn
    {
        HonglornDbFactory ContextFactory { get; }

        public Honglorn(System.Configuration.ConnectionStringSettings connectionStringSettings)
        {
            if (string.IsNullOrWhiteSpace(connectionStringSettings.ProviderName))
            {
                throw new ArgumentException(nameof(connectionStringSettings.ProviderName));
            }

            if (string.IsNullOrWhiteSpace(connectionStringSettings.ConnectionString))
            {
                throw new ArgumentException(nameof(connectionStringSettings.ConnectionString));
            }

            ContextFactory = new HonglornDbFactory(connectionStringSettings);
        }

        public Honglorn(DbConnection connection)
        {
            ContextFactory = new HonglornDbFactory(connection);
        }

        public ICollection<StudentManager> GetStudents()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return db.Student.Select(s => s.PKey).ToList().Select(key => new StudentManager(key, ContextFactory)).ToList();
            }
        }

        public ICollection<HandicapManager> GetHandicaps()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return db.Handicap.Select(s => s.PKey).ToList().Select(key => new HandicapManager(key, ContextFactory)).ToList();
            }
        }

        public ICollection<CourseManager> GetCourses()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return db.Course.Select(s => s.PKey).ToList().Select(key => new CourseManager(key, ContextFactory)).ToList();
            }
        }

        public GameCollection GetGames()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return new GameCollection
                {
                    TraditionalTrackAndFieldGames = db.TraditionalTrackAndFieldGame.Select(g => g.PKey).ToList().Select(key => new TraditionalTrackAndFieldGameManager(key, ContextFactory)).ToList(),
                    CompetitionTrackAndFieldGames = db.CompetitionTrackAndFieldGame.Select(g => g.PKey).ToList().Select(key => new CompetitionTrackAndFieldGameManager(key, ContextFactory)).ToList()
                };
            }
        }

        public ClassService ClassService()
        {
            return new ClassService(ContextFactory);
        }

        public StudentService StudentService()
        {
            return new StudentService(ContextFactory);
        }
    }
}