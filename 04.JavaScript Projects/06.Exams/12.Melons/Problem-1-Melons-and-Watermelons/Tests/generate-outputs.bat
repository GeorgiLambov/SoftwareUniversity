FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    melons.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
