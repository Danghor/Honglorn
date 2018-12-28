using HonglornBL.Models.Entities;

namespace HonglornBL
{
    class DisciplineContainer<T> where T : Discipline
    {
        internal T MaleSprint { get; set; }
        internal T MaleJump { get; set; }
        internal T MaleThrow { get; set; }
        internal T MaleMiddleDistance { get; set; }
        internal T FemaleSprint { get; set; }
        internal T FemaleJump { get; set; }
        internal T FemaleThrow { get; set; }
        internal T FemaleMiddleDistance { get; set; }
    }
}