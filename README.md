# vbnet-format

An opinionated VB.NET source formatter built on Roslyn.

Roslyn's own `Formatter` normalizes indentation and spacing but never introduces a line break, so long lines and long `Sub`/`Function` signatures stay long. vbnet-format wraps them, breaking only where VB already continues a line so that no `_` is ever written. It also sorts, de-duplicates and groups `Imports`.

## Command Line Usage

```
vbnet-format [SUBCOMMAND] [OPTIONS...] [FILES...]
```

## Trademark Disclaimer

vbnet-format is an independent, non-commercial, open-source project and is not affiliated with, sponsored by, or endorsed by Microsoft Corporation.

Visual Basic, VB.NET, and .NET are trademarks of Microsoft Corporation. They are used solely to identify the technologies supported by this project.
