# https://leetcode.com/problems/tenth-line/
# https://leetcode.com/submissions/detail/299297614/

# Read from the file file.txt and output the tenth line to stdout.
#!/bin/bash
i=0
while IFS= read -r line 
do
  if [ $i -eq 9 ]  
  then 
    echo "$line" 
    break 
  fi 
  ((i=i+1)) 
done < "file.txt"