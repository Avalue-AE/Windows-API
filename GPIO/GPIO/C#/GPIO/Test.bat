for %%i in (.) do set TestFolder=%%~nxi
cd ".\%TestFolder%\bin\Debug\"
start "" "%TestFolder%.exe"