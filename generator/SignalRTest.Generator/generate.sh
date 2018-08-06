#!/bin/sh
rm -rf bin
rm -rf obj
dotnet publish -c Release
cd bin/Release/netstandard2.0/publish
rm SignalRTest.Generator.dll



#Remove duplicated reference
rm System.ComponentModel.dll



cd ../../../..
mkdir ../../src/SignalRTest/Assets/Assemblies
mv bin/Release/netstandard2.0/publish/*.dll ../../src/SignalRTest/Assets/Assemblies/
rm -rf bin
rm -rf obj