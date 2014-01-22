#include<stdio.h>
#include<stdlib.h>

int main(void)
{
        int r=1+(int)(rand()*(10.0)/(RAND_MAX+1.0));
        printf("%d\n",r);

        printf("%d\n",RAND_MAX);

        return 0;
}
