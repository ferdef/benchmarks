ifeq ($(OS),Windows_NT)
	CC = cl
	CFLAGS = /O2 /Ot /GL /MD /DNDEBUG
else
	CC = gcc
	CFLAGS = -O2 -s -DNDEBUG
endif

main: main.cpp
	$(CC)  $(CFLAGS) -o c_fibo.exe main.cpp

.PHONY: clean

clean:
	rm -rf *.o