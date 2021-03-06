dofile "functions.lua"

newoption {
   trigger     = "UI",
   value		= "UI",
   description = "Forces the use of a UI project",
   allowed = {
	{ "winforms", "Winforms UI" },
	{ "GTK", "GTK" }
	}
}

-- Solution
solution "Pulsar4X"
	configurations { "Debug", "Release" }
	location "Pulsar4X"
	framework "4.0"

	-- WinForms Project, old UI project
	--project "Pulsar4X.WinForms"
	--	kind "WindowedApp"
	--	language "C#"
	--	location "Pulsar4X/Pulsar4X.WinForms"
	--	objdir "Pulsar4X/Pulsar4X.WinForms/obj"
	--	links { -- Add any needed references here
	--		"Pulsar4X.Lib",
	--		"System",
	--		"System.Data",
	--		"System.Windows.Forms",
	--		"System.Drawing",
	--		"System.Xml",
	--		log4netlib(),
	--		jsonlib(),
	--		opentklib(),
	--		opentkglcontrollib()
	--		}
	--	files { 
	--		"Pulsar4X/Pulsar4X.WinForms/**.cs",
	--		"Pulsar4X/Pulsar4X.WinForms/**.resx",
	--		"Pulsar4X/Pulsar4X.WinForms/**.config",
	--		"Pulsar4X/Pulsar4X.WinForms/Resources/**"
	--		}
	--	excludes {
	--		"Pulsar4X/Pulsar4X.WinForms/bin/**",
	--		"Pulsar4X/Pulsar4X.WinForms/obj/**"
	--		}
	--	
	--	configuration "Resources/**"
	--		buildaction "copy"
	--	
	--	configuration "Debug"
	--		targetdir "Pulsar4X/Pulsar4X.WinForms/bin/Debug"
	--		defines { "DEBUG", "OPENGL", "SPLASHSCREEN", "LOG4NET_ENABLED" }
	--		flags { "Symbols" }
	--		
	--	configuration "Release"
	--		targetdir "Pulsar4X/Pulsar4X.WinForms/bin/Release"
	--		defines { "OPENGL", "SPLASHSCREEN", "LOG4NET_ENABLED" }
	--		flags { "Optimize" }

if ((os.get() == "windows" and _OPTIONS.UI ~= "GTK") or _OPTIONS.UI == "winforms") then
	-- WinForms Project, main UI project
	project "Pulsar4X.UI"
		kind "WindowedApp"
		language "C#"
		location "Pulsar4X/Pulsar4X.UI"
		objdir "Pulsar4X/Pulsar4X.UI/obj"
		links { -- Add any needed references here
			"Pulsar4X.Lib",
			"System",
			"System.Data",
			"System.Windows.Forms",
			"System.Drawing",
			"System.Xml",
			log4netlib(),
			jsonlib(),
			opentklib(),
			opentkglcontrollib(),
			dockPanelSuiteLib()
			}
		files { 
			"Pulsar4X/Pulsar4X.UI/**.cs",
			"Pulsar4X/Pulsar4X.UI/**.resx",
			"Pulsar4X/Pulsar4X.UI/**.config",
			"Pulsar4X/Pulsar4X.UI/Resources/**"
			}
		excludes {
			"Pulsar4X/Pulsar4X.UI/bin/**",
			"Pulsar4X/Pulsar4X.UI/obj/**"
			}
		
		configuration "Resources/**"
			buildaction "copy"
		
		configuration "Debug"
			targetdir "Pulsar4X/Pulsar4X.UI/bin/Debug"
			defines { "DEBUG", "OPENGL", "SPLASHSCREEN", "LOG4NET_ENABLED" }
			flags { "Symbols" }
			
		configuration "Release"
			targetdir "Pulsar4X/Pulsar4X.UI/bin/Release"
			defines { "OPENGL", "SPLASHSCREEN", "LOG4NET_ENABLED" }
			flags { "Optimize" }

else
	-- GTKForms Project, main UI project
	project "Pulsar4X.GTKForms"
		kind "WindowedApp"
		language "C#"
		location "Pulsar4X/Pulsar4X.GTKForms"
		objdir "Pulsar4X/Pulsar4X.GTKForms/obj"
		links { -- Add any needed references here
			"Pulsar4X.Lib",
			"System",
			"atk-sharp, Version=2.12.0.0, Culture=neutral, PublicKeyToken=35e10195dab3c99f",
			"gdk-sharp, Version=2.12.0.0, Culture=neutral, PublicKeyToken=35e10195dab3c99f",
			"glade-sharp, Version=2.12.0.0, Culture=neutral, PublicKeyToken=35e10195dab3c99f",
			"gtk-sharp, Version=2.12.0.0, Culture=neutral, PublicKeyToken=35e10195dab3c99f",
			"Mono.Posix",
			"pango-sharp, Version=2.12.0.0, Culture=neutral, PublicKeyToken=35e10195dab3c99f",
			log4netlib(),
			jsonlib(),
			}
		files { 
			"Pulsar4X/Pulsar4X.GTKForms/**.cs",
			"Pulsar4X/Pulsar4X.GTKForms/**.stetic",
			"Pulsar4X/Pulsar4X.GTKForms/**.config"
			}
		excludes {
			"Pulsar4X/Pulsar4X.WinForms/bin/**",
			"Pulsar4X/Pulsar4X.WinForms/obj/**"
			}
		
		configuration "Resources/**"
			buildaction "copy"
		
		configuration "Debug"
			targetdir "Pulsar4X/Pulsar4X.WinForms/bin/Debug"
			defines { "DEBUG", 'OPENGL', 'GTKFORM', "SPLASHSCREEN", "LOG4NET_ENABLED" }
			flags { "Symbols" }
			
		configuration "Release"
			targetdir "Pulsar4X/Pulsar4X.WinForms/bin/Release"
			defines { "GTKFORM", 'OPENGL', "SPLASHSCREEN", "LOG4NET_ENABLED" }
			flags { "Optimize" }
end

					
	-- Lib Project, contains game files
	project "Pulsar4X.Lib"
		kind "SharedLib"
		language "C#"
		location "Pulsar4X/Pulsar4X.Lib"
		objdir "Pulsar4X/Pulsar4X.Lib/obj"
		links { -- Add any needed references here
			"System",
			"System.Data",
			"System.Xml",
			"System.Drawing",
			log4netlib(),
			jsonlib()
			}
		files { 
			"Pulsar4X/Pulsar4X.Lib/**.cs",
			"Pulsar4X/Pulsar4X.Lib/Data/**"
			}
			
		configuration { "windows", "Release" }
			
		configuration "Data/**"
			buildaction "copy"
			
		configuration "Debug"
			targetdir "Pulsar4X/Pulsar4X.Lib/bin/Debug"
			defines { "DEBUG", "LOG4NET_ENABLED" }
			flags { "Symbols" }
			
		configuration "Release"
			targetdir "Pulsar4X/Pulsar4X.Lib/bin/Release"
			flags { "Optimize" }

	-- Unit Test Project, contains unit tests
	project "Pulsar4X.Tests"
		kind "SharedLib"
		language "C#"
		location "Pulsar4X/Pulsar4X.Tests"
		objdir "Pulsar4X/Pulsar4X.Tests/obj"
		links { -- Add any needed references here
			"Pulsar4X.Lib",
			"System",
			"System.Data",
			"System.Xml",
			nunitlib()
			}
		files { 
			"Pulsar4X/Pulsar4X.Tests/**.cs",
			}
		
		configuration "Debug"
			targetdir "Pulsar4X/Pulsar4X.Tests/bin/Debug"
			defines { "DEBUG", "LOG4NET_ENABLED" }
			flags { "Symbols" }
			
		configuration "Release"
			targetdir "Pulsar4X/Pulsar4X.Tests/bin/Release"
                        defines { "LOG4NET_ENABLED" }
			flags { "Optimize" }
			
defaultaction "vs2010"

debugoutput()
