# Chia-Metadata
Welcome to the CHIA-Metadata GitHub repository!

CHIA-Metadata is a C# library that serves as a wrapper for Chia NFTs with the CHIP-0007 JSON metadata standard. It simplifies the process of working with Chia NFTs and allows developers to easily create, mint, and manage NFTs on the Chia blockchain.

Here is a code example of how to use CHIA-Metadata to create metadata:
```
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
}
```
And here is a code example of how to use CHIA-Metadata to load metadata:
```
public void TestDeSerialize()
{
    Metadata test = Chia_Metadata.IO.Load(Path.Combine("TestAssets", "CryptoCrests_Templar_Order_1.json"));
}
```
