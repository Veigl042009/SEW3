#include<stdio.h>
int main(){
    int GZ;
    printf("Bitte geben sie eine ganze Zahl ein:");
    scanf("%d", &GZ);

    if (GZ % 2 == 0){
        printf("Die Zahl: %d ist gerade", GZ);
    }else{
        printf("Die Zahl: %d ist ungerade", GZ);
    }
}