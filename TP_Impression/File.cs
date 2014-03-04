using System;
using System.Collections.Generic;
using System.Threading;
namespace Server
{
	public class File
	{
		private List<Job> pendingJobs;
		private object lockPendingJobs = new object();
		private uint lastId = 0;
		private ManualResetEvent blocker;
		public File (ManualResetEvent blocker)
		{
			this.blocker = blocker;
			pendingJobs = new List<Job> ();
		}
		public void add (Job job)
		{
			lock (lockPendingJobs) {
				pendingJobs.Add (job);
				job.id = ++lastId;
				blocker.Set ();
			}
		}
		public Job getNextJob ()
		{
			lock (lockPendingJobs) {
				if (pendingJobs.Count > 0) {
					Job job = pendingJobs [0];
					pendingJobs.RemoveAt (0);
					return job;
				}
				blocker.Reset ();
				return null;
			}	
		}
		public void remove (Job job)
		{
			lock (lockPendingJobs) {
				pendingJobs.Remove (job);
				if (pendingJobs.Count == 0)
					blocker.Reset ();
			}
		}
		public void clear ()
		{
			lock (lockPendingJobs) {
				pendingJobs.Clear ();
			}
		}
	}
}

