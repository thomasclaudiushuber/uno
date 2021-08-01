#!/bin/bash
export BUILD_SOURCESDIRECTORY=`pwd`/..
export BUILD_ARTIFACTSTAGINGDIRECTORY=/tmp/uno-uitests-results
export UNO_UITEST_IOSBUNDLE_PATH="$BUILD_SOURCESDIRECTORY/src/SamplesApp/SamplesApp.iOS/bin/iPhoneSimulator/Release/SamplesApp.app"

# Use this block to run snapshot tests
export UITEST_TEST_MODE_NAME=Snapshots
export UITEST_SNAPSHOTS_GROUP=01

# Use this block to run automated tests
#export UITEST_TEST_MODE_NAME=Automated
#export UNO_UITEST_BUCKET_ID=01

mkdir -p $BUILD_ARTIFACTSTAGINGDIRECTORY

pushd $BUILD_SOURCESDIRECTORY
msbuild /r /p:Configuration=Release $BUILD_SOURCESDIRECTORY/src/SamplesApp/SamplesApp.UITests/SamplesApp.UITests.csproj
popd

./ios-uitest-build.sh
./ios-uitest-run.sh
