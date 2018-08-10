
is_reverse = Array.new(101)


1.upto(is_reverse.length) do |i|
  num = i
  while (num < is_reverse.length)
    is_reverse[num] = !is_reverse[num]
    num += i
  end
end

is_reverse.length.times do|i|
  if (is_reverse[i])
    puts i
  end
end
