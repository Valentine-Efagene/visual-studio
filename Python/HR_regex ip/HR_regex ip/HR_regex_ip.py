import re

regex = re.compile(r"^.{3}\..{3}\..{3}\..{3}$")
strt = "abc.def.ghi.jkx"
strf = "123.123.123.123.123.123"
match = re.match(regex, strt) is not None
print(str(match).lower())
