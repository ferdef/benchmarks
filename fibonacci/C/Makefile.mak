# Version for Windows Visual Studio Compiler (cl)

CC = cl
CFLAGS = /O2 /GL /MD /DNDEBUG
LDFLAGS = /LTCG

SOURCES = main.c fibo.c fibo_iter.c
OBJECTS = $(SOURCES:.c=.obj)
TARGET = fibo.exe

$(TARGET): $(OBJECTS)
    $(CC) $(CFLAGS) $(LDFLAGS) -Fe$@ $(OBJECTS)

.c.obj:
    $(CC) $(CFLAGS) -c $<

.PHONY: clean

clean:
    del /Q *.obj $(TARGET)
