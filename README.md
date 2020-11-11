# Pan Zoom Orbit Unity package

This project provides a unity package for panning, zooming and orbiting a camera. The project is setup as an [embedded package](https://docs.unity3d.com/2020.1/Documentation/Manual/CustomPackages.html#EmbedMe), and releases are distributed using the **release** branch.

To include in a project add the following to the manifest file:

```
"metervara.pan-zoom-orbit": "https://github.com/metervara/pan-zoom-orbit.git#release"
```

Or add it using the git option in the package manager. 

**Make sure to target the #release branch, since the master branch contains an entire Unity project**

### Credit

[Zoom implementation adapted from here](https://stackoverflow.com/a/44418717/3729686)