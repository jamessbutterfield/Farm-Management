namespace Classes.Job
{
    using Classes.LinkedList;
    using Classes.User;

    public class Job
    {
        private int JobID;
        private string Title;
        private string Description;
        private DateTime DateCreated;
        private DateTime DateCompleted;
        private bool Status;
        private int HoursOrMilesStart;
        private int HoursOrMilesComplete;
        private LinkedList Parts;
        private User UserCreated;

        public Job(int JobID, string Title, string Description, DateTime DateCreated, DateTime DateCompleted, bool Status, int HoursOrMilesStart, int HoursOrMilesComplete, LinkedList Parts, User UserCreated)
        {
            this.JobID = JobID;
            this.Title = Title;
            this.Description = Description;
            this.DateCreated = DateCreated;
            this.DateCompleted = DateCompleted;
            this.Status = Status;
            this.HoursOrMilesStart = HoursOrMilesStart;
            this.HoursOrMilesComplete = HoursOrMilesComplete;
            this.Parts = Parts;
            this.UserCreated = UserCreated;
        }

        public Job(int JobID, string Title, string Description, DateTime DateCreated, bool Status, int HoursOrMilesStart, int HoursOrMilesComplete, LinkedList Parts, User UserCreated)
        {
            this.JobID = JobID;
            this.Title = Title;
            this.Description = Description;
            this.DateCreated = DateCreated;
            this.Status = Status;
            this.HoursOrMilesStart = HoursOrMilesStart;
            this.HoursOrMilesComplete = HoursOrMilesComplete;
            this.Parts = Parts;
            this.UserCreated = UserCreated;
        }

        public int GetJobID()
        {
            return JobID;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetDescription()
        {
            return Description;
        }

        public DateTime GetDateCreated()
        {
            return DateCreated;
        }

        public DateTime GetDateCompleted()
        {
            return DateCompleted;
        }

        public bool GetStatus()
        {
            return Status;
        }

        public int GetHoursOrMilesStart()
        {
            return HoursOrMilesStart;
        }

        public int GetHoursOrMilesComplete()
        {
            return HoursOrMilesComplete;
        }

        public LinkedList GetParts()
        {
            return Parts;
        }

        public User GetUserCreated()
        {
            return UserCreated;
        }
    }
}
