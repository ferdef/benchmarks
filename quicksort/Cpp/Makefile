ifeq ($(OS),1Windows_NT)
	CC = cl
	CFLAGS = /O2 /Ot /GL /MD /DNDEBUG
else
	CC = g++
	CFLAGS = -O2 -s -DNDEBUG
endif

main: main.cpp
	$(CC)  $(CFLAGS) -o qs.exe main.cpp

.PHONY: clean

clean:
	rm -rf *.o
