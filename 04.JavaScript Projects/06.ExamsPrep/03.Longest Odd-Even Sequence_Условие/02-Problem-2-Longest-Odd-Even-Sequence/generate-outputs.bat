FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java LongestOddEvenSequence < "%%f" > "!file:.in.txt=.out.txt!"
)
