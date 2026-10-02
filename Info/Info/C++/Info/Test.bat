for %%i in (.) do set TestFolder=%%~nxi
cd ".\x64\Release\"
start "" "%TestFolder%.exe"