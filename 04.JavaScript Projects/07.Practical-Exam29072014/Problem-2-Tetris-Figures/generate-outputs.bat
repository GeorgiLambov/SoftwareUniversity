FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node countTetrisFigures.js < "%%f" > "!file:.in.txt=.out.txt!"
)
