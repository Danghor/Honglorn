using HonglornBL.MasterData.Course;
using HonglornBL.MasterData.Handicap;
using HonglornBL.MasterData.StudentCourse;
using HonglornBL.MasterData.StudentHandicap;
using HonglornBL.Models.Framework;
using System;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using HonglornBL.Game;
using HonglornBL.Game.Competition.TrackAndField;
using HonglornBL.Game.Traditional.TrackAndField;
using HonglornBL.MasterData.Class;
using HonglornBL.MasterData.Student;

namespace HonglornBL
{
    public class Honglorn
    {
        HonglornDbFactory ContextFactory { get; }

        public Honglorn(ConnectionStringSettings connectionStringSettings)
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

        public ClassService ClassService() => new ClassService(ContextFactory);

        public CourseService CourseService() => new CourseService(ContextFactory);

        public StudentService StudentService() => new StudentService(ContextFactory);

        public HandicapService HandicapService() => new HandicapService(ContextFactory);

        public StudentCourseService StudentCourseService() => new StudentCourseService(ContextFactory);

        public StudentHandicapService StudentHandicapService() => new StudentHandicapService(ContextFactory);
    }
}