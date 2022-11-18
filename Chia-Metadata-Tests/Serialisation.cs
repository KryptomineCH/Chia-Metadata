using System;
using System.IO;
using Xunit;

namespace Chia_Metadata_Tests
{
    public class Serialisation
    {
        [Fact]
        public void TestSerialize()
        {
            FileInfo testfile = new FileInfo("TestSerialize");
            if (testfile.Exists) testfile.Delete();
            Chia_Metadata.Metadata data = new Chia_Metadata.Metadata
                (
                name: "TestSerialize name",
                description: $"Test Metadata Description{Environment.NewLine}with 2 lines.",
                mintingTool: "Chia-Metadata-UnitTests",
                sensitiveContent: false,
                seriesNumber: 1,
                seriesTotal: 1
                );
            data.Save(testfile.Name);
            string content = File.ReadAllText(testfile.FullName+".json");
            { }
        }
    }
}