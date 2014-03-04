using System;
using System.Threading;
using System.Collections.Generic;

namespace Server
{
	public class PrinterPool
	{
		private File file;
		private ManualResetEvent eventHasJobs;
		private Dictionary<Printer, Thread> printers;
		
		public PrinterPool ()
		{
			eventHasJobs = new ManualResetEvent (false);
			this.file = new File (eventHasJobs);
			printers = new Dictionary<Printer, Thread> ();
		}
		public void add (Printer printer)
		{
			printer.setPool (this);
			Thread printerThread = new Thread (printer.work);
			printerThread.Start ();
			printers.Add (printer, printerThread);
		}
		public void remove (Printer printer)
		{
		}
		public ManualResetEvent getEventHasJob ()
		{
			return eventHasJobs;
		}
		public File getFile ()
		{
			return file;
		}
	}
}

