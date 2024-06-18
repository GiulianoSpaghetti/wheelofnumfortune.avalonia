using System;
using WixSharp;

namespace wheelofnumfortune_setup
{
    internal class Program
    {
        static void Main()
        {
            {
                var project = new Project("wheelofnumfortune.avalonia",
                                  new Dir(@"[ProgramFiles64Folder]\\wheelofnumfortune.avalonia",
                                      new DirFiles(@"*.*"),
                                      new Dir("runtimes",
                                          new Dir("win-x64",
                                                new Dir("native",
                                                    new File("runtimes\\win-x64\\native\\av_libglesv2.dll"),
                                                    new File("runtimes\\win-x64\\native\\libHarfBuzzSharp.dll"),
                                                    new File("runtimes\\win-x64\\native\\libSkiaSharp.dll")
                                                )
                                            )
                                     )
                            ),
                            new Dir(@"%ProgramMenu%",
                             new ExeFileShortcut("WheelOfNumFortune", "[ProgramFiles64Folder]\\wheelofnumfortune.avalonia\\wheelofnumfortune.avalonia.Desktop.exe", "") { WorkingDirectory = "[INSTALLDIR]" }
                          )//,
                           //new Property("ALLUSERS","0")
                );

                project.GUID = new Guid("68B61DE0-07A0-499E-B3FB-F15873641EB4");
                project.Version = new Version("0.1");
                project.Platform = Platform.x64;
                project.SourceBaseDir = "C:\\Users\\numer\\source\\repos\\wheelofnumfortune.avalonia\\wheelofnumfortune.avalonia\\wheelofnumfortune.avalonia.Desktop\\bin\\Release\\net8.0-windows10.0.22621.0";
                project.LicenceFile = "LICENSE.rtf";
                project.OutDir = "E:\\";
                project.ControlPanelInfo.Manufacturer = "Giulio Sorrentino";
                project.ControlPanelInfo.Name = "WheelOfNumFortune.Avalonia";
                project.ControlPanelInfo.HelpLink = "https://github.com/numerunix/WheelOfNumFortune.Avalonia/issues";
                project.Description = "Programma di enigmistica che consiste nello scoprire una frase caricata da internet scoprendo manualmente una lettera per volta";
                //            project.Properties.SetValue("ALLUSERS", 0);
                project.BuildMsi();
            }
        }
    }
}