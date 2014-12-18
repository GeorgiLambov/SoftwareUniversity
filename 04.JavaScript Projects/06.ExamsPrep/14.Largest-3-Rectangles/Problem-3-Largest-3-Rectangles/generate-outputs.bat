FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java Largest3Rectangles < "%%f" > "!file:.in.txt=.out.txt!"
)
