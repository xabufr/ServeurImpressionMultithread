using System;
namespace Server
{
	public class Job
	{
		public uint id;
		public string path;
		public JobState state;

		public Job (string path)
		{
			this.path = path;
			state = new JobState ();
		}
	}
}

