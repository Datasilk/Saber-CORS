var gulp = require('gulp'),
    rename = require('gulp-rename');

var release = 'bin/Release/netcoreapp3.1/';
var publish = 'bin/Publish/CORS';

gulp.task('publish', function () {
    var p = gulp.src(release + 'Saber.Vendor.CORS.dll')
        .pipe(gulp.dest(publish, { overwrite: true }));
    var p = gulp.src('config.template.json')
        .pipe(rename('config.json'))
        .pipe(gulp.dest(publish, { overwrite: true }));
    return p;
});