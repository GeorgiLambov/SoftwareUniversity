FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node ../Estates-Solution/Estates.js < "%%f" > "!file:.in.txt=.out.txt!"
)
PAUSE
