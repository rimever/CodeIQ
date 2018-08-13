require "date"

def isReversible(dateTime)
  strDate = dateTime.strftime("%Y%m%d")
  num = strDate.to_i()
  num2 = num.to_s(2)
  num_reverse = num2.reverse()
  return num2 == num_reverse
end



date = Date.new(1964,10,10)
while (date <= Date.new(2020,7,24)) do
  if isReversible(date) then
      text = date.strftime("%Y/%m/%d")
      puts(text)
  end
  date  = date + 1
end