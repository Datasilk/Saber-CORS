var gulp = require('gulp'),
    rename = require('gulp-rename'),np
    sevenBin = require('7zip-bin'),
    sevenZip = require('node-7z');

var app = 'CORS';
var release = 'bin/Release/net5.0/';
var publish = 'bin/Publish/';

function publishToPlatform(platform) {
    gulp.src(release + platform + '/publish/*')
        .pipe(gulp.dest(publish + '/' + platform + '/' + app, { overwrite: true }));
    //copy & rename config file
    gulp.src('config.template.json')
        .pipe(rename('config.json'))
        .pipe(gulp.dest(publish + '/' + platform + '/' + app, { overwrite: true }))
    return gulp.src('.');
}

gulp.task('publish:win-x64', () => {
    return publishToPlatform('win-x64');
});

gulp.task('publish:linux-x64', () => {
    return publishToPlatform('linux-x64');
});

gulp.task('zip', () => {
    setTimeout(() => {
        //wait 500ms before creating zip to ensure no files are locked
        process.chdir(publish);
        sevenZip.add(app + '.7z', app, {
            $bin: sevenBin.path7za,
            recursive: true
        });
        process.chdir('../..');
    }, 500);
    return gulp.src('.');
});

gulp.task('publish', gulp.series('publish:win-x64', 'publish:linux-x64', 'zip'));