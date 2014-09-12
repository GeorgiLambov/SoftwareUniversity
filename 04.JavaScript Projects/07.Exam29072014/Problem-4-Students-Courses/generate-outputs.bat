FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node studentResults.js < "%%f" > "!file:.in.txt=.out.txt!"
)
