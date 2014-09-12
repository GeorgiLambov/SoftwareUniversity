FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java LogsAggregator < "%%f" > "!file:.in.txt=.out.txt!"
)
