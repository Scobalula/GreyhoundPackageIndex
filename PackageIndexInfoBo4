The following is the hash algorithm for BO4 (credit to DTZxPorter for finding it)

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
