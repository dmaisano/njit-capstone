---
footer: Domenico Maisano
---

# Getting Started

## Introduction

Here is a list of tools you'll need in order to be able to work on the project

- **Version Control**:
  - You will need [Git](https://git-scm.com/) installed and a [Github](https://github.com/) account in order to contribute to the project and send pull requests
- **Text Editor**:
  - I recommend using [Visual Studio Code](https://code.visualstudio.com/) as your editor as it has really good integration with Git and has excellent support for [Vue](https://vuejs.org/v2/guide/) and [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/).
- **Frontend**: You will need [Node.js](https://nodejs.org/en/) if you are working on anything Frontend related. It doesn't really matter if you use the LTS version or current version. I recommend using the most current version.
  - If you are on Mac or Linux I recommend checking out [nvm](https://github.com/nvm-sh/nvm). NVM is a CLI tool that helps manage multiple installations of Node.js on your machine.
- **Backend**: You will need the .NET Core SDK in order to work on the backend code. We will be using version 2.2 until version 3.0 has a bit more supports (better docs, updated via package managers, etc).
- **Database**: [MongoDB](https://docs.mongodb.com/) will be used as the database for the .NET Core API.

> Refer to [#Installation](./#installation) for more info regarding installation on a specific platform.

## Installation

Most of the installations will be done through the use of a package manager.

> If you are on Mac or Windows please make sure you have some sort of Package Manager installed, see below for your system.

#### Windows

[Chocolatey](https://chocolatey.org/install)

> Make sure to have the prompt open as admin when running the `choco` command

#### MacOS

[Homebrew](https://brew.sh)

```sh
# run the following in your terminal
/usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"
```

#### Linux

Use whatever package manager is included in your system

- Debian/Ubuntu - APT
- Arch/Manjaro - Pacman or [Yay](https://github.com/Jguer/yay)

### Git

```sh
# Windows - https://chocolatey.org/packages/git
choco install git

# Mac - https://formulae.brew.sh/formula/git#default
brew install git
```

### Node.js

```sh
# Windows - https://chocolatey.org/packages/nodejs
choco install nodejs

# Mac - https://formulae.brew.sh/formula/node#default
brew install node

# nvm (if you have nvm installed)
nvm install node
```

### Vue.js

```sh
# Node.js must be installed in order to use `npm`

npm install -g @vue/cli
# OR
yarn global add @vue/cli
```

### .NET Core

```sh
# Windows - https://chocolatey.org/packages/dotnetcore-sdk
choco install dotnetcore-sdk

# Mac - https://formulae.brew.sh/cask/dotnet-sdk#default
brew install dotnet-sdk
```

### MongoDB

I generally find it acceptable to use the installer provided on MongoDB's official website. Using a package manager also works, I would go with whatever installation method is easier for you.

```sh
# Windows - https://chocolatey.org/packages/mongodb
choco install mongodb

# Mac - https://docs.mongodb.com/manual/tutorial/install-mongodb-on-os-x/
brew tap mongodb/brew
# then
brew install mongodb-community@4.2
```
