# Angular Samples
Collection of Angular sample projects. Includes `Makefile` to build docker images.

## DBN.Samples.Angular.Ping
Angular sample website that provides a network ping functionality.

### How to build
Use `make` to build Angular project docker image:
```
make ping
```

### How to use
```
docker run -d -p 8080:80 dnbnt/samples-angular-ping:1.0
```

## License
The MIT License (MIT) see [License file](https://github.com/dnbnt/countryinfo/blob/main/LICENSE)