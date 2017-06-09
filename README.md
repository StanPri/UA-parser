ua_parser C# Library
======================

This is the CSharp implementation of [ua-parser](https://github.com/tobie/ua-parser). You can find the latest binaries on NuGet [here](https://www.nuget.org/packages/UAParser/).

[![Build status](https://ci.appveyor.com/api/projects/status/ery4ydoxwtokgjkm?svg=true)](https://ci.appveyor.com/project/enemaerke/uap-csharp)

The implementation uses the shared regex patterns and overrides from regexes.yaml (found in [uap-core](https://github.com/ua-parser/uap-core)). The assembly embeds the latest regex patterns (enabled through a git submodule) which are loaded into the default parser. You can create a parser with more updated regex patterns by using the static methods on `Parser` to pass in specific patterns in yaml format.

Build and Run Tests:
------
Make sure you pull down the submodules that includes the yaml files (otherwise you won't be able to compile):

	git submodule update --init --recursive

You can then build and run the tests by invoking the `build.bat` script

    .\build.bat

Usage:
--------
  Takes the Excel file from the specified directory and appends 3 columns with Browser, Browser Version, and OS information.


Authors:
-------
My work is based on the code of the following people:
  * Søren Enemærke [@sorenenemaerke](https://twitter.com/sorenenemaerke) / [github](https://github.com/enemaerke)
  * Atif Aziz [@raboof](https://twitter.com/raboof) / [github](https://github.com/atifaziz)

  