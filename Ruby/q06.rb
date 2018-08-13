def check(checkValue)
  nowValue = checkValue * 3 + 1

  while  (true) do
    if nowValue % 2 == 0 then
      nowValue = nowValue / 2
    else
      nowValue = nowValue * 3 +1
    end
    if nowValue == checkValue then
      return true
    end
    if nowValue == 1
      return false
    end
  end
end

value = 2
count = 0
while (value <= 10000) do
  if check(value) then
    count = count + 1
  end
  value = value + 2
end
puts count