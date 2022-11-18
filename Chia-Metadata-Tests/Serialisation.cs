using Chia_Metadata;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Chia_Metadata_Tests
{
    public class Serialisation
    {
        [Fact]
        public void TestSerialize()
        {

            FileInfo testfile = new FileInfo(Path.Combine("Temp","TestSerialize"));
            if (testfile.Exists) testfile.Delete();
            if (!testfile.Directory.Exists) testfile.Directory.Create();
            MetadataAttribute[] attributes = new MetadataAttribute[]
            {
                new MetadataAttribute(Trait_Type: "type", Value: "TestAttribute"),
                new MetadataAttribute(Trait_Type: "rarity", Value: 2,Min_Value:0, Max_Value:4),
            };
            Chia_Metadata_CHIP_0007_std.CollectionAttribute[] socialMedia_attributes = new Chia_Metadata_CHIP_0007_std.CollectionAttribute[]
            {
                new Chia_Metadata_CHIP_0007_std.CollectionAttribute(Type: "website", Value: "https://kryptomine.ch/"),
                new Chia_Metadata_CHIP_0007_std.CollectionAttribute(Type: "twitter", Value: "@KryptomineCH"),
                new Chia_Metadata_CHIP_0007_std.CollectionAttribute(Type: "discord", Value: "https://discord.gg/J7z3hVHT8a"),
            };
            Collection testCollection = new Collection(
                Name: "testcollection",
                ID: "4ae1649c-6740-11ed-9022-0242ac120002",
                Description: $"This is a unit test collection.{Environment.NewLine}You should never see it out in the wild!",
                IconLink: "https://nft.kryptomine.ch/Kryptomine_Basecollection/KryptoMine_Logo.png",
                BannerLink: "https://nft.kryptomine.ch/Kryptomine_Basecollection/KryptoMine_Logo.png",
                socialMedia: socialMedia_attributes.ToList());

            Metadata data = new Metadata
                (
                Name: "TestSerialize name",
                Description: $"Test Metadata Description{Environment.NewLine}with 2 lines.",
                Minting_Tool: "Chia-Metadata-UnitTests",
                Sensitive_Content: false,
                Series_Number: 1,
                Series_Total: 10000,
                Attributes: attributes.ToList(),
                Collection: testCollection
                );
            data.Save(testfile.FullName);
            string content = File.ReadAllText(testfile.FullName+".json");
            if (content != "{\r\n  \"format\": \"CHIP-0007\",\r\n  \"name\": \"TestSerialize name\",\r\n  \"description\": \"Test Metadata Description\\r\\nwith 2 lines.\",\r\n  \"minting_tool\": \"Chia-Metadata-UnitTests\",\r\n  \"sensitive_content\": false,\r\n  \"series_number\": 1,\r\n  \"series_total\": 10000,\r\n  \"attributes\": [\r\n    {\r\n      \"name\": \"type\",\r\n      \"value\": \"TestAttribute\"\r\n    },\r\n    {\r\n      \"name\": \"rarity\",\r\n      \"value\": 2,\r\n      \"min_value\": 0,\r\n      \"max_value\": 4\r\n    }\r\n  ],\r\n  \"collection\": {\r\n    \"name\": \"testcollection\",\r\n    \"id\": \"4ae1649c-6740-11ed-9022-0242ac120002\",\r\n    \"attributes\": [\r\n      {\r\n        \"name\": \"description\",\r\n        \"value\": \"This is a unit test collection.\\r\\nYou should never see it out in the wild!\"\r\n      },\r\n      {\r\n        \"name\": \"icon\",\r\n        \"value\": \"https://nft.kryptomine.ch/Kryptomine_Basecollection/KryptoMine_Logo.png\"\r\n      },\r\n      {\r\n        \"name\": \"banner\",\r\n        \"value\": \"https://nft.kryptomine.ch/Kryptomine_Basecollection/KryptoMine_Logo.png\"\r\n      },\r\n      {\r\n        \"name\": \"website\",\r\n        \"value\": \"https://kryptomine.ch/\"\r\n      },\r\n      {\r\n        \"name\": \"twitter\",\r\n        \"value\": \"@KryptomineCH\"\r\n      },\r\n      {\r\n        \"name\": \"discord\",\r\n        \"value\": \"https://discord.gg/J7z3hVHT8a\"\r\n      }\r\n    ]\r\n  }\r\n}")
            {
                throw new Exception("result does not match expected content!");
            }
            { }
        }
        [Fact]
        public void TestDeSerialize()
        {
            Metadata test = Chia_Metadata.IO.Load(Path.Combine("TestAssets", "CryptoCrests_Templar_Order_1.json"));
            { }
        }

    }
}