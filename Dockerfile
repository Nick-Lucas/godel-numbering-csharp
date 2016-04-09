FROM mono:onbuild
ENTRYPOINT ["mono", "./GodelNumbering.exe"]