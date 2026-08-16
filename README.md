# vbnet-format

An opinionated VB.NET source formatter built on Roslyn.

Roslyn's own `Formatter` normalizes indentation and spacing but never introduces a line break, so long lines and long `Sub`/`Function` signatures stay long. vbnet-format wraps them, breaking only where VB already continues a line so that no `_` is ever written. It also sorts, de-duplicates and groups `Imports`.

## Command Line Usage

```
vbnet-format [SUBCOMMAND] [OPTIONS...] [FILES...]
```