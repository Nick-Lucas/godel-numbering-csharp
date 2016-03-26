# Gödel Numbering CSharp

A straightforward implementation of Gödel Numbering, which can convert any `List<int>` to a Gödel Number and back again.

Two classes are included: 
* `Godel` contains methods for encoding & decoding a `List<int>`
* `Godel_Helpers` contains methods for converting to a `List<int>` from (currently just) `String` inputs and back again.

What's this useful for? I have no idea. Its compression efficiency is negative and this only gets worse when you feed it something like Unicode. 
But at least .Net's BigInteger has no 'theoretical' max size, so we can just use this to sadistically challenge our computers with ridiculously sized numbers. 
If you have control of your 'instruction set' and can keep the input values small then you can control the Number size, which I guess is why it was useful for the Turing Machine.

    Console:
    Encoding as Unicode: Mary had a little lamb, its fleece was white as snow
    Godel Number Generated
    Decoded to Unicode: Mary had a little lamb, its fleece was white as snow

    ... and now some stats!
    Godel Digits: 150608 || 000,000 points: 50202
    0.05KB -> 61.07KB
    That's a 1:1221 compression ratio!

