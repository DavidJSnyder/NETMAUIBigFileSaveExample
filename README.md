# NETMAUIBigFileSaveExample

Here is a an example of FileSaver in the .NET Maui Community Toolkit current being unable to save files from a big (multigigabyte stream) on Android even when run (for example) on the Android Subsystem for Windows which has sufficent disk space.  Attempt will fail with the message "Stream was too long" and leave beging a 0 byte file.
