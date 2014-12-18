FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java CognateWords < "%%f" > "!file:.in.txt=.out.txt!"
)
