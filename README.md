# picture-scale
This program can resize a photo to a smaller or larger width, and a smaller or larger height. Keeping the ratio
# how to use
1. the program is used by the command line

1. as the first argument give the path to the folder with the photos you want to change,

1. the second argument give `-h 000` for the expected height (under 000 substitute any height you are interested in pixels) or 
`-w 000` for the expected width (substitute under 000 any width you are interested in pixels)

example launch:

```C:\Users\patryk\Desktop>Resizer.exe "C:\Users\patry\Desktop\sesja\" -w 640
Siema ziomeczku
Znalazłem 5 plików ziomeczku
Zaczynam mielić ziomeczku
Skaluję plik C:\Users\patryk\Desktop\sesja\xyz1.JPG ziomeczku
Skaluję plik C:\Users\patryk\Desktop\sesja\xyz2.JPG ziomeczku
Skaluję plik C:\Users\patryk\Desktop\sesja\xyz3.JPG ziomeczku
Skaluję plik C:\Users\patryk\Desktop\sesja\xyz4.JPG ziomeczku
Skaluję plik C:\Users\patryk\Desktop\sesja\xyz5.JPG ziomeczku
Już ziomeczku
```


output:
Program will create output files in the same directory

```C:\Users\patryk\Desktop\sesja\xyz1-w640.JPG
C:\Users\patryk\Desktop\sesja\xyz2-w640.JPG
C:\Users\patryk\Desktop\sesja\xyz3-w640.JPG
C:\Users\patryk\Desktop\sesja\xyz4-w640.JPG
C:\Users\patryk\Desktop\sesja\xyz5-w640.JPG
```
