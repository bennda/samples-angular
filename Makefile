# makefile variables
IMAGE_NAME=dnbnt/samples-angular-ping
IMAGE_VERSION=1.0
IMAGE_FULLNAME=${IMAGE_NAME}:${IMAGE_VERSION}

.PHONY: help

help:
	@echo "Makefile arguments:"
	@echo ""
	@echo "ping         : build ${IMAGE_FULLNAME}"
	
.DEFAULT_GOAL := help

ping:
	@echo "===== build: ${IMAGE_FULLNAME}"
	@docker build \
		-t "${IMAGE_FULLNAME}" \
		./src/DBN.Samples.Angular.Ping/