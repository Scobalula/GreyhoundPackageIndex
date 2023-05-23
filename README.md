# Greyhound Package Index

[![Discord](https://img.shields.io/badge/chat-Discord-blue.svg)](https://discord.gg/RyqyThu)

The Greyhound Package Index is an ongoing community effort to supply [Greyhound](https://github.com/Scobalula/Greyhound) with meaningful filenames for assets across various Call of Duty titles. It is a continuation of [DTZxPorter's](https://github.com/dtzxporter) [CommunityNameDB](https://github.com/dtzxporter/CommunityNameDB).

| Index | Progress |
|---|---|
xAnims | 34.68% |
xImages | 66.68% |
xMaterials | 61.12% |
xModels | 69.78% |
xSounds | 35.55% |
xStrings | 76.75% |

| Title | Packages Used |
|---|---|
Vanguard | [xsounds](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xsounds.csv), [xstrings](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xstrings.csv) |
Black Ops Cold War | [xanims](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xanims.csv), [ximages](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_ximages.csv), [xmaterials](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xmaterials.csv), [xmodels](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xmodels.csv), [xsounds](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xsounds.csv), [xstrings](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xstrings.csv) |
Black Ops 4 | [xanims](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xanims.csv), [ximages](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_ximages.csv), [xmaterials](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xmaterials.csv), [xmodels](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xmodels.csv), [xsounds](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/FNV1A/fnv1a_xsounds.csv) |
Black Ops III | [sab](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/BO3/bo3_sab.csv) |
Black Ops II | [ipak](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/BO2/bo2_ipak.csv), [sab](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/PackageIndexSources/BO2/bo2_sab.csv) |

## Package Index Tool

[Package Index Tool](https://github.com/Scobalula/GreyhoundPackageIndex/tree/master/PackageIndexTool) is used to convert package indexes between the `.WNI`, `.CSV`, and `.TXT` formats.

The FNV-1a hash algorithm, provided by [DTZxPorter](https://github.com/dtzxporter), is used by Black Ops 4, Black Ops Cold War and Vanguard.

```cpp
const uint64_t FNVPrime = 0x100000001B3;
const uint64_t FNVOffset = 0xCBF29CE484222325;

uint64_t Hash(const char* Data, uint64_t Size)
{
    uint64_t Result = FNVOffset;

    for (uint64_t i = 0; i < Size; i++)
    {
        Result ^= Data[i];
        Result *= FNVPrime;
    }

    return Result;
}

auto Example = Hash("void", strlen("void"));
```


## Contributing

To contribute to the Package Index, [submit a new Issue](https://github.com/Scobalula/GreyhoundPackageIndex/issues) using the provided template. For unverified filenames, ensure that you adhere to the [Community Asset Naming Specification](https://github.com/Scobalula/GreyhoundPackageIndex/blob/master/.github/CONTRIBUTING.md).
