using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace Tools {
    /*This class is used to save a logs messages and print in the console.*/
    public class Logger {

        private static Logger instance;
        private String filename;
        private String dirMonth;
        private String dirYear;
        private String path = @"c:\logs";
        private String dynamicPath;

        private Logger () {
        }

        private void init ( String projectName ) {
            this.dynamicPath = path + "\\" + projectName;
            FileManager.createDirectory ( path, projectName );//C:\logs\projectname

            dirYear = "" + DateTime.UtcNow.Year;
            FileManager.createDirectory ( this.dynamicPath, dirYear );//C:\logs\projectname\\year
            this.dynamicPath += "\\" + dirYear;

            dirMonth = DateTime.UtcNow.ToString ( "MMM", CultureInfo.InvariantCulture );
            FileManager.createDirectory ( this.dynamicPath, dirMonth );//C:\logs\projectname\\year\\month
            this.dynamicPath += "\\" + dirMonth;

            filename = ( DateTime.UtcNow.Day < 10 ) ? "0" + DateTime.UtcNow.Day : "" + DateTime.UtcNow.Day;
            filename = dirMonth + "_" + filename;
        }

        /// <summary>
        /// Function to get the static instance using singleton pattern.
        /// </summary>
        /// <param name="projectname">The projectname is used to create the directory and the log file.</param>
        /// <returns>Logger Object</returns>
        public static Logger getInstance ( String projectName ) {
            if ( instance == null ) {
                instance = new Logger ();
            }
            instance.init ( projectName );
            return instance;
        }

        public void d ( String identifier, String message ) {
            String log = "d\t" + identifier + "\t\t" + message;
            writeLog ( log );
        }

        public void v ( String identifier, String message ) {
            String log = "v\t" + identifier + "\t\t" + message;
            writeLog ( log );
        }

        public void i ( String identifier, String message ) {
            String log = "i\t" + identifier + "\t\t" + message;
            writeLog ( log );
        }

        public void q ( String identifier, String message ) {
            String log = "q\t" + identifier + "\t\t" + message;
            writeLog ( log );
        }

        public void w ( String identifier, String message ) {
            String log = "w\t" + identifier + "\t\t" + message;
            writeLog ( log );
        }

        public void e ( String identifier, Exception ex ) {
            String log = "e\t" + identifier + "\t\t" + ex.Message;
            writeException ( log );
        }

        private void writeLog ( string Log ) {
            try {
                String hour = ( DateTime.Now.Hour < 10 ) ? "0" + DateTime.Now.Hour : "" + DateTime.Now.Hour;
                String minute = ( DateTime.Now.Minute < 10 ) ? "0" + DateTime.Now.Minute : "" + DateTime.Now.Minute;
                String second = ( DateTime.Now.Second < 10 ) ? "0" + DateTime.Now.Second : "" + DateTime.Now.Second;
                String milisecond = ( DateTime.Now.Millisecond < 10 ) ? "00" + DateTime.Now.Second : ( ( DateTime.Now.Millisecond < 100 ) ? "0" + DateTime.Now.Second : "" + DateTime.Now.Second );
                Log = hour + ":" + minute + ":" + second + ":" + milisecond + "\t" + "\t" + Log;
                System.IO.StreamWriter wLog = new System.IO.StreamWriter ( this.dynamicPath + String.Format ( @"\{0}.txt",
                    filename ), true );
                Console.WriteLine ( Log );
                wLog.WriteLine ( Log );
                wLog.Close ();
            } catch ( Exception ex ) {
                ex.ToString ();
            }
        }

        private void writeQuery ( string Log ) {
            try {
                String hour = ( DateTime.Now.Hour < 10 ) ? "0" + DateTime.Now.Hour : "" + DateTime.Now.Hour;
                String minute = ( DateTime.Now.Minute < 10 ) ? "0" + DateTime.Now.Minute : "" + DateTime.Now.Minute;
                String second = ( DateTime.Now.Second < 10 ) ? "0" + DateTime.Now.Second : "" + DateTime.Now.Second;
                String milisecond = ( DateTime.Now.Millisecond < 10 ) ? "00" + DateTime.Now.Second : ( ( DateTime.Now.Millisecond < 100 ) ? "0" + DateTime.Now.Second : "" + DateTime.Now.Second );
                Log = hour + minute + second + milisecond + "\t" + "\t" + Log;
                System.IO.StreamWriter wLog = new System.IO.StreamWriter ( dynamicPath + String.Format ( @"\{0}.txt",
                    filename + "_query" ), true );
                wLog.WriteLine ( Log );
                wLog.Close ();
            } catch ( Exception ex ) {
                ex.ToString ();
            }
        }

        private void writeException ( string Log ) {
            try {
                String hour = ( DateTime.Now.Hour < 10 ) ? "0" + DateTime.Now.Hour : "" + DateTime.Now.Hour;
                String minute = ( DateTime.Now.Minute < 10 ) ? "0" + DateTime.Now.Minute : "" + DateTime.Now.Minute;
                String second = ( DateTime.Now.Second < 10 ) ? "0" + DateTime.Now.Second : "" + DateTime.Now.Second;
                String milisecond = ( DateTime.Now.Millisecond < 10 ) ? "00" + DateTime.Now.Second : ( ( DateTime.Now.Millisecond < 100 ) ? "0" + DateTime.Now.Second : "" + DateTime.Now.Second );
                Log = hour + ":" + minute + ":" + second + ":" + milisecond + "\t" + "\t" + Log;
                Log = hour + ":" + minute + ":" + second + ":" + milisecond + "\t" + "\t" + Log;
                System.IO.StreamWriter wLog = new System.IO.StreamWriter ( this.dynamicPath + String.Format ( @"\{0}.txt",
                    filename + "_exception_" ), true );
                wLog.WriteLine ( Log );
                Console.WriteLine ( Log );
                wLog.Close ();
            } catch ( Exception ex ) {
                ex.ToString ();
            }
        }
    }

    public class FileManager {
        public static Int32 createDirectory ( String path, String name ) {
            String absolutePath = String.Format ( @"{0}\{1}", path, name );
            try {
                if ( Directory.Exists ( absolutePath ) ) {
                    return 0;
                }
                DirectoryInfo di = Directory.CreateDirectory ( absolutePath );
            } catch ( Exception e ) {
                e.ToString ();
                return -1;
            }
            return 1;
        }
    }
}