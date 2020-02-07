# https://leetcode.com/problems/valid-phone-numbers/
# https://leetcode.com/submissions/detail/301141194/

# Read from the file file.txt and output all valid phone numbers to stdout.
#!/bin/bash
r1="^[0-9]{3}-[0-9]{3}-[0-9]{4}$"
r2="^\([0-9]{3}\) [0-9]{3}-[0-9]{4}$"

while IFS= read -r line 
do
  if [[ $line =~ $r1 ]]; then 
    echo "$line" 
  fi

  if [[ $line =~ $r2 ]]; then 
    echo "$line" 
  fi 
done < "file.txt"