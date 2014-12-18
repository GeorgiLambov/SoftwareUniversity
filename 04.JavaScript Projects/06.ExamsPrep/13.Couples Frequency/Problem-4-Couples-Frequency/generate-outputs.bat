FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java CouplesFrequency < "%%f" > "!file:.in.txt=.out.txt!"
)
