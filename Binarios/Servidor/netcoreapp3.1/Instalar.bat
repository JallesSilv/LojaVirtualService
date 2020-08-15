@echo Instalando Servico
@setlocal enableextensions
@cd /d "%~dp0"

set pathServico="%CD%\Service.exe"

sc.exe create "Loja Virtual" binpath=%pathServico%
sc.exe start "Loja Virtual"