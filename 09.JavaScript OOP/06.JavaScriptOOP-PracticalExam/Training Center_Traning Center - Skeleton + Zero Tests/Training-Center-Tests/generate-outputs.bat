FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node ../Training-Center-Solution/Training-Center.js < "%%f" > "!file:.in.txt=.out.txt!"
)
PAUSE
